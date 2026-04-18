import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaCircular } from './media-circular';

describe('MediaCircular', () => {
  let component: MediaCircular;
  let fixture: ComponentFixture<MediaCircular>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MediaCircular],
    }).compileComponents();

    fixture = TestBed.createComponent(MediaCircular);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
