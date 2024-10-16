import { AfterViewInit, Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router'; 
@Component({
  selector: 'app-moviesindex',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './moviesindex.component.html',
  styleUrl: './moviesindex.component.css'
})
export class MoviesindexComponent implements AfterViewInit{
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
