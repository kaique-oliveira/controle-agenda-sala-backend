
import { Routes, Route } from 'react-router-dom';
import { Home } from './components/Home';
import { Login } from './components/Login';

import './styles.css'
export const App = () => {
    return (

        <Routes>
            <Route path='/login' element={ <Login /> } />
            <Route path='/home' element={<Home />} />
        </Routes>

            
    )
}