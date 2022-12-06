import React, { createContext, useState, useEffect, useContext } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from  '../services/api'


interface IDadosUsuario{
    token: string;
    usuario: {
        nome: string;
        email: string;
        tipo: string;
    }
}

interface IDadosLogin{
    email: string;
    senha: string;
}

interface IRetornoContextoLogin{
    logado: boolean;
    usuario: IDadosUsuario | null;
    loading: boolean;
    fazerLogin(dadosLogin: IDadosLogin): Promise<void>;
    fazerLogout(): void;
}

interface IContextoLoginProps {
    children?: React.ReactNode;
  }


//criando um contexto, utilizando o hook do react
const ContextoLogin = createContext<IRetornoContextoLogin>({} as IRetornoContextoLogin);

export const LoginProvider: React.FC<IContextoLoginProps> = ({children}) => {

    const [usuario, setUsuario] = useState<IDadosUsuario | null>(null);
    const [loading, setLoading] = useState<boolean>(true);


    //busca a key token e usuario no local storange, caso existir dados do usuario o objeto é atualizado
    useEffect(() => { 
       async function carregarStorange(){
           const storangeUsuario = await AsyncStorage.getItem('usuario');
           const storangeToken = await AsyncStorage.getItem('token');

           console.log(storangeToken, storangeUsuario);

           if (storangeUsuario && storangeToken) {
               setUsuario(JSON.parse(storangeUsuario));    
           }
        }
        
        carregarStorange();
        setLoading(false);
    }, []);

    async function fazerLogin(dadosLogin : IDadosLogin) {
        api.post("login/usuario", dadosLogin)
        .then((response) => {
            setUsuario(response.data);

            AsyncStorage.setItem('usuario', JSON.stringify(response.data.usuario));
            AsyncStorage.setItem('token', response.data.token);
        })
        .catch((err) => {
            switch (err.code) {
                case "ERR_NETWORK":
                    alert("ops! sem acesso a internet!");
                    break;
                case "ERR_BAD_REQUEST":
                    alert(`Ops, ${err.response.data}`);
                    break;
                default:
                    alert("ops! algo deu errado!");
                }

            console.log(err)
        });
    }

    function fazerLogout() {
        AsyncStorage.clear().then(() => {
            setUsuario(null);
        })
    }

    return (
        <ContextoLogin.Provider value={{logado: !!usuario, usuario, loading, fazerLogin, fazerLogout}}>
            {children}
        </ContextoLogin.Provider>
    );
}

export function useLogin() {
    const context = useContext(ContextoLogin);
    return context;
};