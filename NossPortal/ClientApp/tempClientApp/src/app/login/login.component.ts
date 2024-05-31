import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    standalone: true,
  imports: [MatFormFieldModule, HttpClientModule,  MatInputModule, MatButtonModule, MatIconModule],
})

export class LoginComponent {
    model: any = {};

    constructor(private http: HttpClient, private router: Router) { }

    hide = true;
    clickEvent(event: MouseEvent) {
      this.hide = !this.hide;
      event.stopPropagation();
    }

    onSubmit() {
        this.http.post('/api/auth/login', this.model).subscribe(
            response => {
                console.log('Login successful');
                // Redirecionar para a página principal ou salvar o token
                this.router.navigate(['/']);
            },
            error => {
                console.error('Login failed');
            }
        );
    }
}
