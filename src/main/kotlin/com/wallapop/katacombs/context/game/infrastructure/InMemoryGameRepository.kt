package com.wallapop.katacombs.context.game.infrastructure

import com.wallapop.katacombs.context.game.domain.Game
import com.wallapop.katacombs.context.game.domain.GameRepository
import org.springframework.stereotype.Repository

@Repository
class InMemoryGameRepository : GameRepository {
    override fun save(game: Game) {

    }
}
