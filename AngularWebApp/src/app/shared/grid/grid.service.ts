import { Injectable } from '@angular/core';
import * as _ from 'lodash';


@Injectable({
  providedIn: 'root'
})
export class GridService {
  private _columnConfigs: Array<IColumnConfig> = [
    {
      Table: GridTable.User,
      Columns: [

        {
          Name: 'USER.NAME',
          ProgId: 'USER_NAME',
          TranslateIt: true,
          Field: 'name',
          Type: {
            progId: GridColumnType.Text
          }
        },

      ]
    }
  ];

  constructor() { }

  public getColumnConfig = (table: GridTable): Array<IColumn> => {
    return _.find(this._columnConfigs, c => c.Table === table).Columns;
  }

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
