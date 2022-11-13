import { User } from "./App";

//define the type of property passed to the component
interface Props {
    user: User;
}

function Header({user}: Props) {
    return <h4>Welcome {user.name}</h4>
}

export default Header;
