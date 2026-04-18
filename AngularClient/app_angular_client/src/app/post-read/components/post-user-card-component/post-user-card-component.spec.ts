import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostUserCardComponent } from './post-user-card-component';

describe('PostUserCardComponent', () => {
  let component: PostUserCardComponent;
  let fixture: ComponentFixture<PostUserCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PostUserCardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(PostUserCardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
