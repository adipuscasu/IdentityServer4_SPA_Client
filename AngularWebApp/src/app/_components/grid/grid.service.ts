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
          Name: 'USER.ID',
          ProgId: 'USER_ID',
          Field: 'Id',
          Type: {
            progId: GridColumnType.Numeric
          }
        },
        {
          Name: 'USER.NAME',
          ProgId: 'USER_NAME',
          TranslateIt: true,
          Field: 'fullName',
          Type: {
            progId: GridColumnType.Text
          }
        },
        {
          Name: 'USER.USERNAME',
          ProgId: 'USER_USERNAME',
          Field: 'username',
          Type: {
            progId: GridColumnType.Text
          }
        },
        {
          Name: 'USER.ADDRESS',
          ProgId: 'USER_ADDRESS',
          Field: 'address.fullAddress',
          Type: {
            progId: GridColumnType.Text
          }
        },
        {
          Name: 'USER.MOBILE',
          ProgId: 'USER_MOBILE',
          Field: 'mobile',
          Type: {
            progId: GridColumnType.Text
          }
        },
        {
          Name: 'USER.ORGANIZATION',
          ProgId: 'USER_ORGANIZATION',
          Field: 'organization.name',
          Type: {
            progId: GridColumnType.Text
          }
        },
        {
          Name: 'Active',
          ProgId: 'actie',
          Field: 'active',
          Type: {
            progId: GridColumnType.Boolean
          }
        }
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
