import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtendableContentComponent } from './extendable-content-component';

describe('ExtendableContentComponent', () => {
  let component: ExtendableContentComponent;
  let fixture: ComponentFixture<ExtendableContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExtendableContentComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ExtendableContentComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
