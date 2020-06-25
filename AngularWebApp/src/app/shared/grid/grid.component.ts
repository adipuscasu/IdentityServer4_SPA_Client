import { Component, OnInit, Input, Output, EventEmitter, HostBinding, DoCheck, ViewChild } from '@angular/core';
import * as moment from 'moment';
import { TranslateService } from '@ngx-translate/core';
import { GridColumnType, GridTable, GridService } from './grid.service';
import * as _ from 'lodash';
import { GridApi, ColumnApi, IDatasource, IGetRowsParams, PaginationChangedEvent } from 'ag-grid-community';
import { AgGridColumn } from 'ag-grid-angular';
import { IconCellRendererComponent } from './icon-cell-renderer/icon-cell-renderer.component';
import { ActionCellRendererComponent } from './action-cell-renderer/action-cell-renderer.component';


@Component({
  selector: 'isspa-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit, DoCheck {
  private _oldRows: Array<any>;
  private _columnDefinitions: Array<IColumn> = [];
  private _gridApi: GridApi;
  private _columnApi: ColumnApi;
  private _allowSelectedEvent: boolean = true;
  @HostBinding('class') public classes = 'd-flex flex-column col-12';


  @Input() public rows: Array<any>;
  @Input() public pagination: boolean;
  @Input() public table: GridTable;
  @Input() public rowSelection = 'single';
  @Input() public actionCallbacks: Array<{ key: string, callback: Function }>;
  @Input() public useInfiniteScrolling: boolean;
  @Output() public selected: EventEmitter<any> = new EventEmitter<any>();
  public agColumnDefinitions: Array<AgGridColumn>;
  public frameworkComponents = {
    iconRenderer: IconCellRendererComponent,
    actionRenderer: ActionCellRendererComponent
  };
  public paginationSizes: Array<number> = [
    10,
    30,
    50,
    100
  ];
  public currentPage: number = 1;
  public paginationSize: number = this.paginationSizes[0];
  public totalPages: number;
  public gridContext: { component: any } = { component: this };

  constructor(
    private readonly _gridService: GridService,
    private readonly _translateService: TranslateService
  ) { }

  public ngOnInit() {
    this.initColumnDefinitions();
    console.log('in grid component:', this.rows);
  }

  public ngDoCheck() {
    if (_.isEqual(this.rows, this._oldRows))
      return;

    this._oldRows = this.rows;

    this.setIdNumeric();

    this.setRowData();
  }

  public onGridReady(params) {
    this._gridApi = params.api;
    this._columnApi = params.columnApi;

    this.setRowData();

    this._gridApi.refreshCells({ force: true });
    // this._agGrid.rowHeight = 35;
  }

  private setIdNumeric() {
    if (_.isNil(this.rows) || _.isEmpty(this.rows))
      return;

    _.forEach(this.rows, r => {
      if (!r.id)
        return;

      r.Id = _.parseInt(r.id);
    });
  }

  private setRowData() {
    if (!this._gridApi)
      return;

    if (this.useInfiniteScrolling)
      this._gridApi.setDatasource(this.getDataSource());
    else
      this._gridApi.setRowData(this.rows);
  }

  private getDataSource(): IDatasource {
    return {
      rowCount: null,
      getRows: (params: IGetRowsParams) => {
        const rowsThisPage = this.rows.slice(params.startRow, params.endRow);
        let lastRow = -1;
        if (this.rows.length <= params.endRow)
          lastRow = this.rows.length;

        params.successCallback(rowsThisPage, lastRow);
      }
    };
  }

  public onActionTriggered = (functionName: string, row: any): void => {
    if (_.isNil(this.actionCallbacks) || _.isEmpty(this.actionCallbacks))
      return;

    const callback = _.find(this.actionCallbacks, a => a.key === functionName);

    if (!callback)
      return;

    callback.callback(row);
  }

  public onPaginationChanged(event: PaginationChangedEvent) {
    if (!this._gridApi)
      return;

    this.totalPages = this._gridApi.paginationGetTotalPages();
  }

  public onPageChange(value: number) {
    this._gridApi.paginationGoToPage(value - 1);
  }

  public onPaginationSizeChanged(value: number) {
    this.paginationSize = value;
    this._gridApi.paginationSetPageSize(this.paginationSize);
  }

  public onSelectionChanged() {
    if (!this._allowSelectedEvent) {
      this._allowSelectedEvent = true;
      return;
    }

    const selectedRows = this._gridApi.getSelectedRows();

    if (this.rowSelection === 'single') {
      this.selected.emit(_.first(selectedRows));
      this.deselectRows();
    } else
      this.selected.emit(selectedRows);
  }

  public deselectRows() {
    this._allowSelectedEvent = false;
    this._gridApi.deselectAll();
  }

  public refreshGrid() {
    this._gridApi.refreshCells();
  }

  private async initColumnDefinitions() {
    this.agColumnDefinitions = new Array<AgGridColumn>();

    for (const columnDefinition of this._gridService.getColumnConfig(this.table)) {
      const agColumnDefinition: AgGridColumn = new AgGridColumn();

      agColumnDefinition.colId = columnDefinition.ProgId;
      agColumnDefinition.resizable = true;
      agColumnDefinition.headerName = this._translateService.instant(columnDefinition.Name);
      agColumnDefinition.field = columnDefinition.Field;
      agColumnDefinition.tooltipField = columnDefinition.Field;
      agColumnDefinition.sortable = true;
      agColumnDefinition.filter = this.getTypeForColumn(columnDefinition);

      if (columnDefinition.Field === 'Id')
        agColumnDefinition.sort = 'desc';

      this.setCellRenderer(agColumnDefinition, columnDefinition);

      this.agColumnDefinitions.push(agColumnDefinition);
    }
  }

  private getTypeForColumn(columnDefinition: IColumn) {
    if (!_.get(columnDefinition, 'Type.progId'))
      return 'agTextColumnFilter';

    switch (columnDefinition.Type.progId) {
      case GridColumnType.Numeric:
        return 'agNumberColumnFilter';
      case GridColumnType.Date:
        return 'agDateColumnFilter';
      case GridColumnType.Boolean:
        return '';
      default:
        return 'agTextColumnFilter';
    }
  }

  private setCellRenderer(agColumnDefinition: AgGridColumn, columnDefinition: IColumn) {
    console.log('in setCellrenderer: ', agColumnDefinition);
    if (!_.get(columnDefinition, 'Type.progId'))
      return;

    switch (columnDefinition.Type.progId) {
      case GridColumnType.Text:
        agColumnDefinition.cellRenderer = (params) => this.textCellRenderer(params, columnDefinition);
        break;
      case GridColumnType.Date:
        agColumnDefinition.cellRenderer = (params) => this.dateCellRenderer(params, columnDefinition);
        break;
      case GridColumnType.Boolean:
      case GridColumnType.BooleanWithCustomIcon:
        agColumnDefinition.cellRenderer = 'iconRenderer';
        agColumnDefinition.cellRendererParams = {
          columnDefinition: columnDefinition
        };
        break;
      case GridColumnType.Action:
        agColumnDefinition.cellRenderer = 'actionRenderer';
        agColumnDefinition.cellRendererParams = {
          columnDefinition: columnDefinition
        };
        break;
      default:
        return;
    }
  }

  private dateCellRenderer(params: any, columnDefinition: IColumn) {
    if (!params.value)
      return ' - ';

    const format = _.get(columnDefinition, 'DateOptions.Format') || 'DD.MM.YYYY HH:mm';

    return moment(params.value).format(format);
  }

  private textCellRenderer(params: any, columnDefinition: IColumn) {
    if (!params.value)
      return ' - ';

    if (!columnDefinition.TranslateIt)
      return params.value;

    if (!columnDefinition.TranslateOptions)
      return this._translateService.instant(params.value);

    const prefix = columnDefinition.TranslateOptions.Prefix ? columnDefinition.TranslateOptions.Prefix : '';
    const suffix = columnDefinition.TranslateOptions.Suffix ? columnDefinition.TranslateOptions.Suffix : '';

    return this._translateService.instant(prefix + params.value + suffix);
  }

}
