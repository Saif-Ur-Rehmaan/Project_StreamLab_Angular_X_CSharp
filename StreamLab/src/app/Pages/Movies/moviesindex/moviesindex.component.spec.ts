import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesindexComponent } from './moviesindex.component';

describe('MoviesindexComponent', () => {
  let component: MoviesindexComponent;
  let fixture: ComponentFixture<MoviesindexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MoviesindexComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MoviesindexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
