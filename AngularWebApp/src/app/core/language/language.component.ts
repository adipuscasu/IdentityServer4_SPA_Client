import { Component, OnInit, Input } from '@angular/core';
import { LanguageDisplayMode, LanguageEnum, LanguageService } from './language.service';

@Component({
  selector: 'isspa-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.scss']
})
export class LanguageComponent implements OnInit {
  @Input()
  public displayMode: LanguageDisplayMode;

  public languageDisplayMode: typeof LanguageDisplayMode = LanguageDisplayMode;
  public language: typeof LanguageEnum = LanguageEnum;
  constructor(
    private readonly _languageService: LanguageService
  ) { }

  ngOnInit() {
  }
  public changeLanguage(language: LanguageEnum, skipServerUpdate: boolean) {
    this._languageService.changeLanguage(language, skipServerUpdate);
}

public get currentLanguage(): LanguageEnum {
    return this._languageService.currentLanguage;
}
}
