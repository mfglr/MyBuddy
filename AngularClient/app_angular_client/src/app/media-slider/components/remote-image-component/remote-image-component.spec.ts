import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoteImageComponent } from './remote-image-component';

describe('RemoteImageComponent', () => {
  let component: RemoteImageComponent;
  let fixture: ComponentFixture<RemoteImageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemoteImageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(RemoteImageComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
