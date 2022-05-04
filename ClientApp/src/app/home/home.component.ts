import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public isAuthenticated!: boolean;
  
  constructor(private authorizeService: AuthorizeService, private router: Router) { 
    this.authorizeService.isAuthenticated().subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
      if (isAuthenticated) {
        this.router.navigateByUrl('/dashboard');
      } 
    });
  }

  ngOnInit(): void {
  }
}
