import { Component, OnInit } from '@angular/core';
import { Empresa } from '../../models/empresa.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';
import { FormControl, Validators } from '@angular/forms';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css'],
  providers: [EmpresaService, TicketService]
})
export class EmpresaComponent implements OnInit {

  navTitle: any;
  empresaUrl: any; // url - urlparam
  cpfSearch: any; // ngModel

  empresa: Empresa = { // Model de 'Empresa'
    url: 'undefined',
    nome: 'undefined'
  }

  // Formcontrol para Form no Box Esquerdo
  searchControl = new FormControl(null, [Validators.required, Validators.pattern("[0-9]{11}") /* Validators.pattern("[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}") */]);

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private empresaService: EmpresaService,
    private ticketService: TicketService) { }

  ngOnInit(): void {
    this.navTitle = document.getElementById('navTitle');
    // Atribui valor de UrlParam -> ex: resolveja.com/EmpresaAbc <- 'EmpresaAbc' é o UrlParam
    this.empresaUrl = this.activatedRoute.snapshot.paramMap.get('empresa');

    // Realiza consulta com UrlParam e realiza validação de Empresa
    this.loadContent();
  }

  // Realiza busca por URL da empresa -> retorna a página da empresa caso URL exista
  loadContent(): void { 
    this.empresaService.getByUrl(this.empresaUrl).subscribe(
      (result) => {
        this.empresa = result;
        this.navTitle.innerText = this.empresa.nome;
      },
      (error) => {
        this.router.navigate(['home']);
      },
    );
  }

  // Função que realiza busca de Tickets -> box direito
  search(): void {
    alert(this.cpfSearch);
  }

  // Validação de campos - box direito
  validSearchFields(): boolean {
    return this.searchControl.valid;
  }

  // Mensagem de erro para campos inválidos -> box direito
  getErrorMessageSearch() {
    if (this.searchControl.hasError('required')) {
      return 'Você deve informar um CPF válido';
    }
    if (this.searchControl.hasError('pattern')) {
      return 'Você deve informar um CPF válido';
    }
    return null;
  }
}
