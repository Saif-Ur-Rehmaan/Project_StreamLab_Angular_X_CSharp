import { AfterViewInit, Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
@Component({
  selector: 'app-tv-show-index',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './tv-show-index.component.html',
  styleUrl: './tv-show-index.component.css'
})
export class TvShowIndexComponent implements AfterViewInit {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
