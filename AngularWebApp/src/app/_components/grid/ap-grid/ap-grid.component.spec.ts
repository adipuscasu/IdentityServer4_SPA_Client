import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApGridComponent } from './ap-grid.component';

describe('ApGridComponent', () => {
  let component: ApGridComponent;
  let fixture: ComponentFixture<ApGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
