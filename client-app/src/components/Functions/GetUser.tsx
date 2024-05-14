import { useEffect, useState } from "react";

export const GetUser = () => {
  const [user, setUser] = useState<any>({});

  useEffect(() => {
    (async () => {
      const response = await fetch(`http://localhost:5000/api/Auth/user`, {
        headers: { "Content-Type": "application/json" },
        credentials: "include",
      });

      const content = await response.json();

      setUser(content);
    })();
  }, []);

  return { user };
};
