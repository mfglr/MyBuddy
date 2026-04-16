import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoPlayButtonComponent } from './video-play-button-component';

describe('VideoPlayButtonComponent', () => {
  let component: VideoPlayButtonComponent;
  let fixture: ComponentFixture<VideoPlayButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VideoPlayButtonComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(VideoPlayButtonComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
