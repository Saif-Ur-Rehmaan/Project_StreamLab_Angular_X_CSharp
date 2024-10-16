import { Routes } from '@angular/router';
import { IndexComponent } from './Pages/index/index.component';
import { MoviesindexComponent } from './Pages/Movies/moviesindex/moviesindex.component';
import { SingleMovieComponent } from './Pages/Movies/single-movie/single-movie.component';

export const routes: Routes = [
    { path: '', component: IndexComponent ,pathMatch: 'full'},
    { path: 'Movies', component: MoviesindexComponent },
    { path: 'Movies/:id', component: SingleMovieComponent},
];
