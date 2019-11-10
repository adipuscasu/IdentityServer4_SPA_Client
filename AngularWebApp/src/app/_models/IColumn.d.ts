interface IColumn {
  Name?: string;
  ProgId?: string;
  Field?: string;
  Type?: IType;
  Actions?: Array<IColumnAction>;
  TranslateIt?: boolean;
  TranslateOptions?: IColumnTranslateOptions;
  BooleanOptions?: IColumnBooleanOptions;
  DateOptions?: IColumnDateOptions;
}

interface IType extends IBaseModel {
  name?: string;
  progId?: string;
  table?: string;
  active?: boolean;
  parent?: IType;
  sortNumber?: string;
  numberOfConnected?: number;
}
interface IColumnAction {
  FunctionName?: string;
  Icon?: Array<string>;
  Name?: string;
  Css?: string;
  Role?: any;
}
interface IColumnTranslateOptions {
  Prefix?: string;
  Suffix?: string;
  NoValue?: string;
}
interface IColumnBooleanOptions {
  TrueIcon?: Array<string>;
  FalseIcon?: Array<string>;
  TrueIconColor?: string;
  FalseIconColor?: string;
}
interface IColumnDateOptions {
  Format?: string;
}
