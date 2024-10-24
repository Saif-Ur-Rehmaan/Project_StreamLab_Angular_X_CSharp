import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-single-blog',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './single-blog.component.html',
  styleUrl: './single-blog.component.css'
})
export class SingleBlogComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
