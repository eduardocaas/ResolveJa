import { Component } from '@angular/core';
import { Empresa } from '../../models/empresa.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css'],
  providers: [EmpresaService]
})
export class EmpresaComponent {

  navTitle: any;
  empresaUrl: any;

  empresa: Empresa = {
    url: 'undefined',
    nome: 'undefined'
  }

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: EmpresaService) { }

  ngOnInit(): void {
    this.navTitle = document.getElementById('navTitle');
    this.empresaUrl = this.activatedRoute.snapshot.paramMap.get('empresa');

    this.loadContent();
  }

  loadContent(): void {
    this.service.getByUrl(this.empresaUrl).subscribe(
      (result) => {
        this.empresa = result;
        this.navTitle.innerText = this.empresa.nome;
      },
      (error) => {
        this.router.navigate(['home']);
      }, 
    );
  }
}
