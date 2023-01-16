import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditStComponent } from './add-edit-st.component';

describe('AddEditStComponent', () => {
  let component: AddEditStComponent;
  let fixture: ComponentFixture<AddEditStComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditStComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditStComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
