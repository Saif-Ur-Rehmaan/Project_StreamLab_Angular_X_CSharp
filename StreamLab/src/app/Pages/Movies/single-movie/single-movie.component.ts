import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-single-movie',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './single-movie.component.html',
  styleUrl: './single-movie.component.css'
})
export class SingleMovieComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
 
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
 
  }
}
