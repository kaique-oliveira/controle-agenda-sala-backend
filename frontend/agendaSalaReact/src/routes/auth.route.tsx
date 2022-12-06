import { createNativeStackNavigator } from '@react-navigation/native-stack';

import { Login } from "../pages/Login";

const AuthStack = createNativeStackNavigator();

const AuthRoutes: React.FC = () => {
    return (
     
        <AuthStack.Navigator>
            <AuthStack.Screen
                options={{
                    title: '',
                    headerTransparent: true,
                    headerShown: false,                   
                }}
                name="login"
                component={Login} />
        </AuthStack.Navigator>

    );
};

export default AuthRoutes;  