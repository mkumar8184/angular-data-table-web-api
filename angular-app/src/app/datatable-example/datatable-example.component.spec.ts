import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatatableExampleComponent } from './datatable-example.component';

describe('DatatableExampleComponent', () => {
  let component: DatatableExampleComponent;
  let fixture: ComponentFixture<DatatableExampleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatatableExampleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DatatableExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
