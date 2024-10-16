import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleTvShowComponent } from './single-tv-show.component';

describe('SingleTvShowComponent', () => {
  let component: SingleTvShowComponent;
  let fixture: ComponentFixture<SingleTvShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingleTvShowComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingleTvShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
