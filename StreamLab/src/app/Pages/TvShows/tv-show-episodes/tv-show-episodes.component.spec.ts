import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TvShowEpisodesComponent } from './tv-show-episodes.component';

describe('TvShowEpisodesComponent', () => {
  let component: TvShowEpisodesComponent;
  let fixture: ComponentFixture<TvShowEpisodesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TvShowEpisodesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TvShowEpisodesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
