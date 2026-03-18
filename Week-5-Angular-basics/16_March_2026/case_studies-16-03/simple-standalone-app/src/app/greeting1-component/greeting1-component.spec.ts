import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Greeting1Component } from './greeting1-component';

describe('Greeting1Component', () => {
  let component: Greeting1Component;
  let fixture: ComponentFixture<Greeting1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Greeting1Component],
    }).compileComponents();

    fixture = TestBed.createComponent(Greeting1Component);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
