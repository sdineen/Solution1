import Header from './Header';

//define and export an interface for User
export interface User {
  name: string;
}

export default function App() {
//create a user object
  const user: User = { name: "Simon Dineen" }; 
  //pass the user object to the Header component as a prop 
  return <div className="container">    
    <Header user={user} />
  </div>;
}
