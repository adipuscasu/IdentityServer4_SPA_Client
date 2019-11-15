import { Directive, HostListener } from '@angular/core';

@Directive({
  selector: '[isspaClickStopPropagation]'
})
export class ClickStopPropagationDirective {

  @HostListener('click', ['$event'])
  public onClick(event: UIEvent): void {
    event.stopPropagation();
    event.preventDefault();
  }
}
