import { Routes } from '@angular/router';
import { IndexComponent } from './Pages/index/index.component';
import { MoviesindexComponent } from './Pages/Movies/moviesindex/moviesindex.component';
import { MoviesListComponent } from './Pages/Movies/movies-list/movies-list.component';
import { SingleMovieComponent } from './Pages/Movies/single-movie/single-movie.component';
import { TvShowIndexComponent } from './Pages/TvShows/tv-show-index/tv-show-index.component';
import { TvShowListComponent } from './Pages/TvShows/tv-show-list/tv-show-list.component';
import { SingleTvShowComponent } from './Pages/TvShows/single-tv-show/single-tv-show.component';
import { TvShowEpisodesComponent } from './Pages/TvShows/tv-show-episodes/tv-show-episodes.component';
import { PricingComponent } from './Pages/pricing/pricing.component';
import { ContactUsComponent } from './Pages/contact-us/contact-us.component'; 
import { BlogsIndexComponent } from './Pages/Blogs/blogs-index/blogs-index.component';
import { SingleBlogComponent } from './Pages/Blogs/single-blog/single-blog.component';

export const routes: Routes = [
    { path: '', component: IndexComponent ,pathMatch: 'full'},

    { path: 'Movies', component: MoviesindexComponent,pathMatch:'prefix'},
    { path: 'Movies/list', component: MoviesListComponent,pathMatch:'prefix'},
    { path: 'Movies/:id', component: SingleMovieComponent,pathMatch:'prefix'},
    
    { path: 'TvShows', component: TvShowIndexComponent },
    { path: 'TvShows/list', component: TvShowListComponent},
    { path: 'TvShows/:showId', component: TvShowEpisodesComponent},
    { path: 'TvShows/:showId/:episodeId', component: SingleTvShowComponent},
    
    { path: 'Pricing', component: PricingComponent},
    { path: 'Contact', component: ContactUsComponent},

    { path: 'Blogs', component: BlogsIndexComponent},
    { path: 'Blogs/:id', component: SingleBlogComponent},

];
