API de ecommerce

- CRUD usuários
    - Admin ou User
    - Somente o endpoint de criação de usuário é livre de autenticação
    - Se o usuário for admin vai poder editar/excluir/listar e obter dados de todos os usuários
    - Se não for admin, ele só vai poder obter dados do seu próprio usuário
- Login de usuário
- CRUD produtos
    - somente usuário Admin vai poder manipular os produtos
    - Listagem e obter dados do produto não necessita de autenticação
- endpoint de compra
    - precisa estar autenticado

Não é obrigatório banco de dados