using System.Linq;

namespace GameState
{
    public enum PieceType
    {
        Pawn,
        Drone,
        Queen
    }
    public class Piece
    {
        public enum Type
        {
            Pawn,
            Drone,
            Queen
        }
        Type _type;

        public Piece(Type type)
        {
            _type = type;
        }

        public (int x, int y)[] GetPossibleMoves()
        {
            switch (_type)
            {
                case Type.Drone:
                    return new (int x, int y)[] { (1, 1), (1, -1), (-1, -1), (-1, 1) };
                case Type.Pawn:
                    // TODO: Setup moves
                    return new (int x, int y)[] { (1, 1), (1, -1), (-1, -1), (-1, 1) };
                case Type.Queen:
                    // TODO: Setup moves
                    return new (int x, int y)[] { (1, 1), (1, -1), (-1, -1), (-1, 1) };
                default:
                    throw new System.Exception("Invalid piece type");
            }
        }

        public Type GetPieceType()
        {
            return _type;
        }
    }
    public class Tile
    {
        Piece _piece;

        public Piece GetPiece()
        {
            return _piece;
        }

        public bool HasPiece()
        {
            return _piece != null;
        }

        public void SetPiece(Piece piece)
        {
            _piece = piece;
        }
    }

    public class Board
    {
        public int Lines = 8;
        public int Columns = 4;

        public Tile[,] Tiles;

        public Board()
        {
            Tiles = new Tile[,] {
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
                { new Tile(), new Tile(), new Tile(), new Tile(), },
            };
            SetPiecesInInitialPositions();

        }

        public (int x, int y)[] GetValidMoves((int x, int y) tilePosition)
        {
            Tile tile = Tiles[tilePosition.x, tilePosition.y];
            if (!tile.HasPiece())
            {
                return new (int x, int y)[] { };
            }

            Piece piece = tile.GetPiece();
            (int x, int y)[] possibleMoves = piece.GetPossibleMoves();
            return possibleMoves.Where(IsInsideBoard).ToArray();
        }

        void SetPiecesInInitialPositions()
        {
            Tiles[0, 0].SetPiece(new Piece(Piece.Type.Queen));
            Tiles[0, 1].SetPiece(new Piece(Piece.Type.Queen));
            Tiles[1, 0].SetPiece(new Piece(Piece.Type.Queen));

            Tiles[0, 2].SetPiece(new Piece(Piece.Type.Drone));
            Tiles[1, 1].SetPiece(new Piece(Piece.Type.Drone));
            Tiles[2, 0].SetPiece(new Piece(Piece.Type.Drone));

            Tiles[1, 2].SetPiece(new Piece(Piece.Type.Pawn));
            Tiles[2, 1].SetPiece(new Piece(Piece.Type.Pawn));
            Tiles[2, 2].SetPiece(new Piece(Piece.Type.Pawn));

            Tiles[7, 3].SetPiece(new Piece(Piece.Type.Queen));
            Tiles[7, 2].SetPiece(new Piece(Piece.Type.Queen));
            Tiles[6, 3].SetPiece(new Piece(Piece.Type.Queen));

            Tiles[7, 1].SetPiece(new Piece(Piece.Type.Drone));
            Tiles[6, 2].SetPiece(new Piece(Piece.Type.Drone));
            Tiles[5, 3].SetPiece(new Piece(Piece.Type.Drone));

            Tiles[6, 1].SetPiece(new Piece(Piece.Type.Pawn));
            Tiles[5, 2].SetPiece(new Piece(Piece.Type.Pawn));
            Tiles[5, 1].SetPiece(new Piece(Piece.Type.Pawn));
        }

        bool IsInsideBoard((int x, int y) tilePosition)
        {
            return (0 <= tilePosition.x) && (tilePosition.x < Lines) && (0 <= tilePosition.y) && (tilePosition.y < Columns);
        }
    }
}
