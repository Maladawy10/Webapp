import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteStComponent } from './show-delete-st.component';

describe('ShowDeleteStComponent', () => {
  let component: ShowDeleteStComponent;
  let fixture: ComponentFixture<ShowDeleteStComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteStComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDeleteStComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
