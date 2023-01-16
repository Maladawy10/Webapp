import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteSubComponent } from './show-delete-sub.component';

describe('ShowDeleteSubComponent', () => {
  let component: ShowDeleteSubComponent;
  let fixture: ComponentFixture<ShowDeleteSubComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteSubComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDeleteSubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
