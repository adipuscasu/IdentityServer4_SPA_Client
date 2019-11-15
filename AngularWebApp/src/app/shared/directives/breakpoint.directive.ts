import { Directive, OnInit, OnDestroy, TemplateRef, EmbeddedViewRef, ViewContainerRef, Input } from '@angular/core';
import { Subject } from 'rxjs';
import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { BootstrapBreakpoints } from 'src/app/core/css-breakpoints';
import { takeUntil } from 'rxjs/operators';
import * as _ from 'lodash';
import { stringify } from 'querystring';

@Directive({
  selector: '[isspaBreakpoint]'
})
export class BreakpointDirective implements OnInit, OnDestroy {
  private readonly _destroy$: Subject<any> = new Subject<any>();
  private _context: BreakpointContext = new BreakpointContext();
  private _thenTemplateRef: TemplateRef<BreakpointContext> | null = null;
  private _elseTemplateRef: TemplateRef<BreakpointContext> | null = null;
  private _thenViewRef: EmbeddedViewRef<BreakpointContext> | null = null;
  private _elseViewRef: EmbeddedViewRef<BreakpointContext> | null = null;

  constructor(
      private readonly _breakpointObserver: BreakpointObserver,
      private readonly _templateRef: TemplateRef<BreakpointContext>,
      private readonly _viewContainerRef: ViewContainerRef
  ) {
      this._thenTemplateRef = this._templateRef;
  }

  @Input()
  public set isspaBreakpoint(breakpoints: Array<BreakpointContext>) {
      this._context.$implicit = this._context.isspaBreakpoint = breakpoints;
  }

  @Input()
  public set isspaBreakpointThen(templateRef: TemplateRef<BreakpointContext> | null) {
      assertTemplate('isspaBreakpointThen', templateRef);
      this._thenTemplateRef = templateRef;
      this._thenViewRef = null;  // clear previous view if any.
  }

  @Input()
  public set isspaBreakpointElse(templateRef: TemplateRef<BreakpointContext> | null) {
      assertTemplate('isspaBreakpointElse', templateRef);
      this._elseTemplateRef = templateRef;
      this._elseViewRef = null;  // clear previous view if any.
  }

  public ngOnInit() {
      // listen to these dimensions
      this._breakpointObserver.observe([
          BootstrapBreakpoints.XSmall,
          BootstrapBreakpoints.Small,
          BootstrapBreakpoints.Medium,
          BootstrapBreakpoints.Large,
          BootstrapBreakpoints.XLarge
      ])
          .pipe(takeUntil(this._destroy$))
          .subscribe(e => {
              if (!e.matches)
                  return;
              // get the breakpoint
              const currentBreakpoint = this.getBreakpoint(e);
              // handle the change and either display or hide the content
              this.handleBreakpointChange(currentBreakpoint);
          });
  }

  private getBreakpoint(breakpointState: BreakpointState) {
      let bootstrapBreakpoint: BootstrapBreakpoints;

      for (const breakpoint in breakpointState.breakpoints) {
          if (breakpointState.breakpoints.hasOwnProperty(breakpoint)) {
              const element = breakpointState.breakpoints[breakpoint];

              if (element) {
                  bootstrapBreakpoint = breakpoint as BootstrapBreakpoints;
                  break;
              }
          }
      }

      return bootstrapBreakpoint;
  }

  private handleBreakpointChange(currentBreakpoint: BootstrapBreakpoints) {
      if (!currentBreakpoint) { // oh well, life sucks
          this._viewContainerRef.clear();
          return;
      }
      // if we have something
      if (!!_.some(this._context.$implicit, b => b === currentBreakpoint.toString())) {
          if (!this._thenViewRef) {
              this._viewContainerRef.clear();
              this._elseViewRef = null;

              if (this._thenTemplateRef) {
                  // let there be view
                  this._thenViewRef = this._viewContainerRef.createEmbeddedView(this._thenTemplateRef, this._context);
              }
          }
      } else {
          // we don't have a match
          // let's check the else
          if (!this._elseViewRef) {
              this._viewContainerRef.clear();
              this._thenViewRef = null;

              if (this._elseTemplateRef) {
                  // let there be another view
                  this._elseViewRef = this._viewContainerRef.createEmbeddedView(this._elseTemplateRef, this._context);
              }
          }
      }
  }

  public ngOnDestroy() {
      this._destroy$.next();
      this._destroy$.complete();
      this._destroy$.unsubscribe();
  }

}

export class BreakpointContext {
  public $implicit: any = null;
  public isspaBreakpoint: any = null;
}

function assertTemplate(property: string, templateRef: TemplateRef<any> | null): void {
  const isTemplateRefOrNull = !!(!templateRef || templateRef.createEmbeddedView);
  if (!isTemplateRefOrNull) {
      throw new Error(`${property} must be a TemplateRef, but received '${stringify(templateRef)}'.`);
  }
}
