import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalMediaCircular } from './local-media-circular';

describe('LocalMediaCircular', () => {
  let component: LocalMediaCircular;
  let fixture: ComponentFixture<LocalMediaCircular>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LocalMediaCircular],
    }).compileComponents();

    fixture = TestBed.createComponent(LocalMediaCircular);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
