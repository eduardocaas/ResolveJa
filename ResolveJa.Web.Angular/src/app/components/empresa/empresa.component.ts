import { Component, OnInit } from '@angular/core';
import { Empresa } from '../../models/empresa.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css'],
  providers: [EmpresaService]
})
export class EmpresaComponent implements OnInit {

  navTitle: any;
  empresaUrl: any;
  cpf: any;

  empresa: Empresa = {
    url: 'undefined',
    nome: 'undefined'
  }

  // Formcontrol para Form no Box Esquerdo
  searchControl = new FormControl(null, [/*Validators.required, */ Validators.pattern("[0-9]{11}") /* Validators.pattern("[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}") */]);

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: EmpresaService) { }

  ngOnInit(): void {
    this.navTitle = document.getElementById('navTitle');
    this.empresaUrl = this.activatedRoute.snapshot.paramMap.get('empresa');

    this.loadContent();
  }

  loadContent(): void { // Realiza busca por URL da empresa -> retorna a página da empresa caso URL exista
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

  search(): void {
    alert(this.cpf);
  }

  getErrorMessageSearch() {
    /*if (this.searchControl.hasError('required')) {
      return 'Você deve informar um CPF';
    }*/
    if (this.searchControl.hasError('pattern')) {
      return 'Você deve informar um CPF válido';
    }
    return null;
  }
}
