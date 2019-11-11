import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TitleService {
  private readonly _titleSource: Subject<ITitle> = new Subject<ITitle>();

  public _title$: Observable<ITitle> = this._titleSource.asObservable();

  constructor() { }

  public setTitle(title: ITitle) {
    this._titleSource.next(title);
  }
}
