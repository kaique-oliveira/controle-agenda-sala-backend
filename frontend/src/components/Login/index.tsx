import './styles.css';
import { Link } from 'react-router-dom';
import {useState, useEffect} from 'react';

import calendarioLogo from '../../assets/calendario.svg'

export function Login() {
    const [setor, setSetor] = useState('');
    const [senha, setSenha] = useState('');
    let rota: string = ''

    const redirectHome = () => {
        if (setor && senha) {
            rota = '/home';
        } 
    }
    
    return (
        <main className='container-login'>
            <div className='container-img'>
                <img src={calendarioLogo} alt="" />
            </div>

            <div className='container-form'>
                <div className='container-campos-login'>
                    <label htmlFor="combo-setor">Setor</label>
                
                    <select
                        name="combo-setor"
                        id="setor"
                        onChange={e => setSetor(e.target.value)}
                    >
                        <option id='optionOne' value="">Selecione um setor</option>
                        <option value="0">Suporte</option>
                    </select>
                </div>
           
                <div className='container-campos-login'>

                    <label htmlFor="senha">Senha</label>
                    <input
                        name='senha'
                        type="password"
                        onChange={e => setSenha(e.target.value)}
                    />
                </div>
                
                <Link type='button' onClick={redirectHome()} to={`${rota}`} className='button-link'> Login </Link>
           
            </div>
        </main>
    )
}