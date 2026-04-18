import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoteMediaCircular } from './remote-media-circular';

describe('RemoteMediaCircular', () => {
  let component: RemoteMediaCircular;
  let fixture: ComponentFixture<RemoteMediaCircular>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemoteMediaCircular],
    }).compileComponents();

    fixture = TestBed.createComponent(RemoteMediaCircular);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
