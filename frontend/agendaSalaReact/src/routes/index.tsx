import React from 'react';
import { View, ActivityIndicator } from 'react-native';

import { useLogin } from '../contexts/contextoLogin';

import AuthRoutes from './auth.route';
import AppRoutes from './home.route';

const Routes: React.FC = () => {
    const { logado, loading } = useLogin();

    if(loading) {
        return (
            <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
                <ActivityIndicator size="large" color="#999" />
            </View >
        );
    } 

    return logado ? <AppRoutes/> : <AuthRoutes/>
    
};

export default Routes;