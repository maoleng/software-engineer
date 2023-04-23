<?php declare(strict_types=1);

namespace App\Enums;

use BenSampo\Enum\Contracts\LocalizedEnum;
use BenSampo\Enum\Enum;

final class AdminRole extends Enum implements LocalizedEnum
{

    public const ADMIN = 1;
    public const ACCOUNTANT = 2;

}
