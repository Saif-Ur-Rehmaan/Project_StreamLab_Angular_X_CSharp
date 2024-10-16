import { AfterViewInit, Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
@Component({
  selector: 'app-movies-list',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './movies-list.component.html',
  styleUrl: './movies-list.component.css'
})
export class MoviesListComponent implements AfterViewInit {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
 
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
 
  }
}
