import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TvShowIndexComponent } from './tv-show-index.component';

describe('TvShowIndexComponent', () => {
  let component: TvShowIndexComponent;
  let fixture: ComponentFixture<TvShowIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TvShowIndexComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TvShowIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
