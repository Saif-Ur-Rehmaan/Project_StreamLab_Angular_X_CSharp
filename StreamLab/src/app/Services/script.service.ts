import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'any'
})
export class ScriptService {
  BaseScripts:Array<string> = [
    "assets/js/jquery-3.6.0.min.js",
    "assets/js/asyncloader.min.js",
    "assets/js/bootstrap.min.js",
    "assets/js/jquery.waypoints.min.js",
    "assets/js/jquery.counterup.min.js",
    "assets/js/popper.min.js",
    "assets/js/swiper-bundle.min.js",
    "assets/js/isotope.pkgd.min.js",
    "assets/js/jquery.magnific-popup.min.js",
    "assets/js/slick.min.js",
    "assets/js/streamlab-core.js",
    "assets/js/script.js",
    "assets/js/owl.carousel.min.js"
  ];
  constructor() { }

  loadScript(url: string) {
    const body = <HTMLDivElement>document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }

   RemoveAllBaseScripts(){
      
    
    Array.from(document.scripts).forEach((script, index) => {
      this.BaseScripts.forEach(script2 => {
        if (script.src.includes(script2)) {
          script.remove();
        }
      });
    });
  
  }
  LoadAllBaseScripts() {

      
      console.log('load scripts loaded');
    
    this.BaseScripts.forEach(script => this.loadScript(script));
  }
}
