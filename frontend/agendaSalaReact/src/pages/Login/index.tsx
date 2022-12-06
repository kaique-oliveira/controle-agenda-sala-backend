import React, {useState } from 'react';
import { useLogin } from '../../contexts/contextoLogin';

import { Botao } from '../../components/Botao';
import { Input } from '../../components/input';
import {
    Container,
    ContainerHeader,
    Descrition,
    ContainerInput,
    ContainerBody,
    ContainerFooter,
    Logo
} from './styles';


interface IDadosLogin{
    email: string;
    senha: string;
}


const Login: React.FC = () => {

    const { fazerLogin } = useLogin();

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    async function handlerLogin() {
    
        if (email && senha) {
            const dados: IDadosLogin = {
                email: email,
                senha: senha,
            }

            const res = await fazerLogin(dados);
           
        } else {
            alert('Ops, os campos devem ser informados!')
        }
        
    }

    return (
            <Container>
                <ContainerHeader>
                <Logo source={require('../../../assets/logoInterfocus.png')}/>
                </ContainerHeader>

                <ContainerBody>
                    <ContainerInput>
                    <Input
                        leftIcon
                        iconName='at'
                        iconSize={30}
                        placeholder='Digite seu e-mail Interfocus'
                        
                        onChangeText={e => setEmail(e)}
                    />
                    <Input
                        leftIcon
                        iconName='lock-closed'
                        iconSize={25}
                        placeholder='Digite sua senha'
                        secureTextEntry={true}
                        onChangeText={s => setSenha(s)}
                    />
                    </ContainerInput>
                   
                <Botao
                    iconName='door-open'
                    titulo='Entrar'                   
                    onPress={handlerLogin}
                />
                    
                </ContainerBody>

                <ContainerFooter>
                <Descrition>Cadastrar-se</Descrition>
                </ContainerFooter>
           </Container>     
    );
};


export { Login };



