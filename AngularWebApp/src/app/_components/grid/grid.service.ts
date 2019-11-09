import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GridService {

  constructor() { }
}

export enum GridTable {
  User = 'GOT_USER',
}

export enum GridColumnType {
  Text = 'TEXT',
  Boolean = 'BOOLEAN',
  Date = 'DATE',
  Numeric = 'NUMERIC',
  Action = 'ACTION',
  BooleanWithCustomIcon = 'BOOLEAN_CUSTOM_ICON'
}
