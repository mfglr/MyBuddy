import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoUserMediaComponent } from './no-user-media-component';

describe('NoUserMediaComponent', () => {
  let component: NoUserMediaComponent;
  let fixture: ComponentFixture<NoUserMediaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NoUserMediaComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NoUserMediaComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
