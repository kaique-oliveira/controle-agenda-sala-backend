import { Calendario } from '../Calendario'
import { Card } from '../Card'

import './styles.css'

export function Home() {
    return (
        <main className='container-home'>
            <section className='container-form'>

                <div className='container-campos-home'>
                    <div>
                    <label htmlFor="combo-ambiente">Ambiente</label>
                
                    <select
                        name="combo-ambiente"
                        id="setor"
                    >
                        <option id='optionOne' value="">Selecione um ambiente</option>
                        <option value="0">Sala 1</option>
                    </select>
                  </div>
                </div>

                <Calendario/>

                <div className='container-btn-add'>
                    <button>
                        <span className="material-symbols-outlined">add</span> Agendar
                    </button>
                </div>
                {/* <div className='container-campos-home'>
                    <div>
                        <label htmlFor="horInicial">Inicio</label>
                        <input
                            name='horInicial'
                            type="time"
                        />
                    </div>

                    <div>
                        <label htmlFor="horFinal">Término</label>
                        <input
                            name='horFinal'
                            type="time"
                        />
                    </div>
                </div> */}

            </section>
            <section className='container-agendamentos'>
                <div className='container-cards'>
                    <Card
                        ambiente='Sala 1'
                        setor='Suporte técnico'
                        data='22 de Novembro, segunda-feira'
                        horarioInicial='12:15:00'
                        horarioFinal='13:00:00' />
                     <Card
                        ambiente='Sala 1'
                        setor='Suporte técnico'
                        data='22 de Novembro, segunda-feira'
                        horarioInicial='12:15:00'
                        horarioFinal='13:00:00' />
                     <Card
                        ambiente='Sala 1'
                        setor='Suporte técnico'
                        data='22 de Novembro, segunda-feira'
                        horarioInicial='12:15:00'
                        horarioFinal='13:00:00' />
                     <Card
                        ambiente='Sala 1'
                        setor='Suporte técnico'
                        data='22 de Novembro, segunda-feira'
                        horarioInicial='12:15:00'
                        horarioFinal='13:00:00' />
                     <Card
                        ambiente='Sala 1'
                        setor='Suporte técnico'
                        data='22 de Novembro, segunda-feira'
                        horarioInicial='12:15:00'
                        horarioFinal='13:00:00' />
                     <Card
                        ambiente='Sala 1'
                        setor='Suporte técnico'
                        data='22 de Novembro, segunda-feira'
                        horarioInicial='12:15:00'
                        horarioFinal='13:00:00' />
                </div>
            </section>
        </main>
    )
}