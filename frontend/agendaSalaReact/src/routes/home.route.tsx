import { createNativeStackNavigator } from '@react-navigation/native-stack';

import Home from "../pages/Home";
import Agendamento from '../pages/Agendamento'

const AppStack = createNativeStackNavigator();

const AppRoutes: React.FC = () => (
    <AppStack.Navigator>
        <AppStack.Screen
            options={{
                title: '',
                headerTransparent: true,
                headerShown: false,                   
            }}
            name="Home"
            component={Home} />
    </AppStack.Navigator>
);

export default AppRoutes;  