import './styles.css';

export type CardProps = {
    ambiente: string;
    setor: string;
    data: string;
    horarioInicial: string;
    horarioFinal: string;
}

export function Card(props: CardProps) {
    return (
        <div className='card'>
            <div>
                <strong>{props.ambiente} | { props.setor }</strong> 
            </div>
            <div>
                <small>{props.data} - {props.horarioInicial} às { props.horarioFinal }</small>
            </div>   
        </div>
    )   
}                                                                                                                   