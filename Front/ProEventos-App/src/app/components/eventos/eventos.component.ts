import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/Evento';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] =[];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem: number = 80;
  public margemImagem: number = 2;
  public mostrarImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any)  => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

    modalRef?: BsModalRef;
  public ngOnInit() {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public getEventos(): void {
        this.eventoService.getEventos().subscribe({
        next: (_eventos: Evento[]) => {
          this.eventos = _eventos,
          this.eventosFiltrados = this.eventos
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao carregar eventos.', 'Erro!');
        },
        complete: () => this.spinner.hide()
      });

      // (_eventos: Evento[]) => {
      //   this.eventos = _eventos,
      //   this.eventosFiltrados = this.eventos
      // },
      // error => console.log(error)
    // );
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento deletado com sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
