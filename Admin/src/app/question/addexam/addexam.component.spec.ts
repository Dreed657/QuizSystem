import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddexamComponent } from './addexam.component';

describe('AddexamComponent', () => {
  let component: AddexamComponent;
  let fixture: ComponentFixture<AddexamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddexamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddexamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
